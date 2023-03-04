using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class AggregatorService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();
        private IAggregatorRepository _aggregatorRepository = new AggregatorRepository();
        private IClientRepository _clientRepository = new ClientRepository();

        //public List<ComboTagGroupCountProductCountOrderOutputModel> GetGroupTagCountProductsCountOrdersByClientId(int clientId)
        //{
        //    var resultDto = _aggregatorRepository.GetGroupTagCountProductsCountOrdersByClientId(clientId);
        //    var resultModel = AvgPercentOfCountProductsAndOrders(resultDto);

        //    return resultModel;
        //}

        //private List<ComboTagGroupCountProductCountOrderOutputModel> AvgPercentOfCountProductsAndOrders(List<ComboTagGroupCountProductCountOrderDto> combosDtos)
        //{
        //    List<ComboTagGroupCountProductCountOrderOutputModel> result = new();
        //    if (combosDtos.Count > 0)
        //    {
        //        int maxValueProduct = combosDtos.MaxBy(c => c.CountProducts).CountProducts;
        //        int maxValueOrder = combosDtos.MaxBy(c => c.CountOrders).CountOrders;
        //        result = combosDtos.Select(c =>
        //        {
        //            int percentProduct = c.CountProducts * 100 / maxValueProduct;
        //            int percentOrder = c.CountOrders * 100 / maxValueOrder;
        //            int avgPercent = (percentProduct + percentOrder) / 2;

        //            var comboModel = new ComboTagGroupCountProductCountOrderOutputModel
        //            {
        //                Group = _instanceMapper.IMapper.Map<GroupOutputModel>(c.Group),
        //                Tag = _instanceMapper.IMapper.Map<TagOutputModel>(c.Tag),
        //                AvgPercentOfCountProductsAndOrders = avgPercent
        //            };

        //            return comboModel;
        //        }).ToList();
        //    }

        //    return result;
        //}

        private List<ComboTagGroupOutputModel> CalcPointsForComboTagGroupByIdClient(int id)
        {
            if (_clientRepository.GetClientById(id) == null)
            {
                throw new ArgumentNullException("Этого клиента нет");
            }

            List<ComboTagGroupDto> ComboTagGroupDtos = UnionActualComboTagGroup(id);
            List<ComboTagGroupDto> actualComboTagGroupDtos = DeleteNotLikedCombo(ComboTagGroupDtos);

            if (actualComboTagGroupDtos.Count == 0)
            {
                throw new ArgumentNullException("Нет данных о рейтингах комбинаций");
            }

            List<ComboTagGroupOutputModel> ComboTagGroupOutputModels = _instanceMapper.MapComboTagGroupDtoToComboTagGroupOutputModel(actualComboTagGroupDtos);
            List<ComboTagGroupOutputModel> result = CalcPointsForOrders(actualComboTagGroupDtos, ComboTagGroupOutputModels);
            for (int i = 0; i < actualComboTagGroupDtos.Count; i++)
            {
                if (actualComboTagGroupDtos[i].AvgScore != null)
                {
                    result[i].PointForCombo += CalcPointForAvgScore(actualComboTagGroupDtos[i], result[i].PointForCombo);
                }
            }

            int maxPoint = result.MaxBy(r => r.PointForCombo).PointForCombo;

            for (int i = 0; i < actualComboTagGroupDtos.Count; i++)
            {
                if (actualComboTagGroupDtos[i].IsLiked == true)
                {
                    result[i].PointForCombo = maxPoint;
                }
            }

            return result;
        }

        private List<ComboTagGroupDto> UnionActualComboTagGroup(int id)
        {
            List<ComboTagGroupDto> result = _aggregatorRepository.GetGroupTagCountProductsCountOrdersByClientId(id);
            List<ComboTagGroupDto> avgScores = _aggregatorRepository.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(id);
            List<ComboTagGroupDto> wishes = _aggregatorRepository.GetComboTagGroupOfLikeOrDislikeByClientId(id);

            #region
            //foreach (ComboTagGroupDto w in wishes)
            //{
            //    if (!result.Exists(r => (r.Group == w.Group) && (r.Tag == w.Tag)))
            //    {
            //        result.Add(w);
            //    }
            //    else
            //    {
            //        int i = result.FindIndex(r => (r.Group == w.Group) && (r.Tag == w.Tag));
            //        if (i >= 0)
            //        {
            //            result[i].IsLiked = w.IsLiked;
            //        }
            //    }
            //}
            #endregion

            UnionComboTagGroupWithWishes(wishes, result);

            foreach (ComboTagGroupDto s in avgScores)
            {
                int i = result.FindIndex(r => (r.Group == s.Group) && (r.Tag == s.Tag));
                if (i >= 0)
                {
                    result[i].AvgScore = s.AvgScore;
                }
            }

            return result;
        }

        private void UnionComboTagGroupWithWishes(List<ComboTagGroupDto> wishes, List<ComboTagGroupDto> actualCombo)
        {

            foreach (ComboTagGroupDto w in wishes)
            {
                foreach (ComboTagGroupDto combo in actualCombo)
                {
                    if (w.Tag == null && w.Group == combo.Group)
                    {
                        combo.IsLiked = w.IsLiked;
                    }
                    else if (w.Group == null && w.Tag == combo.Tag)
                    {
                        combo.IsLiked = w.IsLiked;
                    }
                    else if (w.Group == combo.Group && w.Tag == combo.Tag)
                    {
                        combo.IsLiked = w.IsLiked;
                    }
                    else
                    {
                        actualCombo.Add(w);
                    }
                }
            }
        }

        private List<ComboTagGroupDto> DeleteNotLikedCombo(List<ComboTagGroupDto> combinations)
        {
            List<ComboTagGroupDto> result = combinations;

            foreach (ComboTagGroupDto c in result)
            {
                if (c.IsLiked == false)
                {
                    result.Remove(c);
                }
            }

            return result;
        }

        private List<ComboTagGroupOutputModel> CalcPointsForOrders(List<ComboTagGroupDto> comboTagGroupDtos, List<ComboTagGroupOutputModel> comboTagGroupOutputModels)
        {
            var result = comboTagGroupOutputModels;

            if (comboTagGroupOutputModels.Count > 0)
            {

                int maxValueProduct = comboTagGroupDtos.MaxBy(c => c.CountProducts).CountProducts;
                int maxValueOrder = comboTagGroupDtos.MaxBy(c => c.CountOrders).CountOrders;

                for (int i = 0; i < comboTagGroupDtos.Count; i++)
                {
                    int percentProduct = comboTagGroupDtos[i].CountProducts * 100 / maxValueProduct;
                    int percentOrder = comboTagGroupDtos[i].CountOrders * 100 / maxValueOrder;
                    int avgPercent = (percentProduct + percentOrder) / 2;
                    result[i].PointForCombo = avgPercent;
                }
            }

            return result;
        }

        private int CalcPointForAvgScore(ComboTagGroupDto combo, int pointForCombo)
        {
            double[] limitScoreForCombo = new double[] { 1.9, 2.9, 3.5, 4.5, 5 };
            int[] insertsForComboWithTag = new int[] { -30, -20, 0, 10, 20 };
            int[] insertsForComboWithoutTag = new int[] { -20, -10, 0, 5, 10 };
            int result = -100;
            int j = 0;

            if (combo.Tag is null)
            {

                for (int i = 0; i < limitScoreForCombo.Length; i++)
                {
                    if (combo.AvgScore <= limitScoreForCombo[i])
                    {
                        result = (pointForCombo * insertsForComboWithoutTag[j]) / 100;
                        break;
                    }

                    j += 1;
                }

                return result;
            }
            else
            {
                for (int i = 0; i < limitScoreForCombo.Length; i++)
                {
                    if (combo.AvgScore <= limitScoreForCombo[i])
                    {
                        result = (pointForCombo * insertsForComboWithTag[j]) / 100;
                        break;
                    }

                    j += 1;
                }

                return result;
            }
        }
    }
}
