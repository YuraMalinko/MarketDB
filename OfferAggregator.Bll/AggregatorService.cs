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
        private IProductsRepository _productsRepository = new ProductsRepository();
        private IProductsReviewsAndStocksRepository _reviews = new ProductsReviewsAndStocksRepository();

        public List<SelectProductForClientOutputModel> SelectOfPotentialProductsForClient(int clientId)
        {

            if (_clientRepository.GetClientById(clientId) == null)
            {
                throw new ArgumentNullException("Такого пользователя нет");
            }

            List<ComboTagGroupOutputModel> combinations = CalcPointsForComboTagGroupByIdClient(clientId);
            List<FullProductDto> products = SortProductsForClient(clientId);
            List<SelectProductForClientOutputModel> allSelectProducts = _instanceMapper.MapFullProductDtoToSelectProductForClientOutputModel(products);
            PurchaseProbabilityRatingCalculation(combinations, products, allSelectProducts);
            allSelectProducts.RemoveAll(p => p.PurchaseProbability == 0);
            allSelectProducts.Sort();

            return allSelectProducts;
        }

        private List<ComboTagGroupOutputModel> CalcPointsForComboTagGroupByIdClient(int id)
        {
            if (_clientRepository.GetClientById(id) == null)
            {
                throw new ArgumentNullException("Этого клиента нет");
            }

            List<ComboTagGroupDto> ComboTagGroupDtos = UnionActualComboTagGroup(id);
            DeleteNotLikedCombo(ComboTagGroupDtos);

            if (ComboTagGroupDtos.Count == 0)
            {
                throw new ArgumentNullException("Нет данных о рейтингах комбинаций");
            }

            List<ComboTagGroupOutputModel> ComboTagGroupOutputModels = _instanceMapper.MapComboTagGroupDtoToComboTagGroupOutputModel(ComboTagGroupDtos);
            CalcPointsForOrders(ComboTagGroupDtos, ComboTagGroupOutputModels);
            for (int i = 0; i < ComboTagGroupDtos.Count; i++)
            {
                if (ComboTagGroupDtos[i].AvgScore != null)
                {
                    ComboTagGroupOutputModels[i].PointForCombo += CalcPointForAvgScore(ComboTagGroupDtos[i], ComboTagGroupOutputModels[i].PointForCombo);
                }
            }

            double maxPoint = ComboTagGroupOutputModels.MaxBy(r => r.PointForCombo).PointForCombo;

            if (maxPoint == 0)
            {
                maxPoint = 100;
            }

            for (int i = 0; i < ComboTagGroupDtos.Count; i++)
            {
                if (ComboTagGroupDtos[i].IsLiked == true)
                {
                    ComboTagGroupOutputModels[i].PointForCombo = maxPoint;
                }
            }

            return ComboTagGroupOutputModels;
        }

        private List<ComboTagGroupDto> UnionActualComboTagGroup(int id)
        {
            List<ComboTagGroupDto> result = _aggregatorRepository.GetGroupTagCountProductsCountOrdersByClientId(id);
            List<ComboTagGroupDto> avgScores = _aggregatorRepository.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(id);
            List<ComboTagGroupDto> wishes = _aggregatorRepository.GetComboTagGroupOfLikeOrDislikeByClientId(id);

            UnionComboTagGroupWithWishes(wishes, result);

            foreach (ComboTagGroupDto s in avgScores)
            {
                int i = result.FindIndex(r => (r.GroupId == s.GroupId) && (r.TagId == s.TagId));
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
                if (actualCombo.Exists(c => w.GroupId == c.GroupId || w.TagId == c.TagId))
                {
                    bool addIsLiked=false;

                    foreach (ComboTagGroupDto combo in actualCombo)
                    {
                        if (w.TagId == null && w.GroupId == combo.GroupId)
                        {
                            combo.IsLiked = w.IsLiked;
                            addIsLiked = true;
                        }
                        else if (w.GroupId == null && w.TagId == combo.TagId)
                        {
                            combo.IsLiked = w.IsLiked;
                            addIsLiked = true;
                        }
                        else if (w.GroupId == combo.GroupId && w.TagId == combo.TagId)
                        {
                            combo.IsLiked = w.IsLiked;
                            addIsLiked = true;
                        }
                    }
                    if (!addIsLiked)
                    {
                        actualCombo.Add(w);
                    }
                }
                else
                {
                    actualCombo.Add(w);
                }
            }
        }

        private void DeleteNotLikedCombo(List<ComboTagGroupDto> combinations)
        {
            foreach (ComboTagGroupDto c in combinations)
            {
                if (c.IsLiked == false)
                {
                    combinations.Remove(c);
                }
            }
        }

        private void CalcPointsForOrders (List<ComboTagGroupDto> comboTagGroupDtos, List<ComboTagGroupOutputModel> comboTagGroupOutputModels)
        {
            if (comboTagGroupOutputModels.Count > 0)
            {

                double maxValueProduct = comboTagGroupDtos.MaxBy(c => c.CountProducts).CountProducts;
                double maxValueOrder = comboTagGroupDtos.MaxBy(c => c.CountOrders).CountOrders;

                for (int i = 0; i < comboTagGroupDtos.Count; i++)
                {
                    double percentProduct = Math.Round(comboTagGroupDtos[i].CountProducts / maxValueProduct * 100,2);
                    double percentOrder = Math.Round(comboTagGroupDtos[i].CountOrders / maxValueOrder * 100, 2);
                    double avgPercent = (percentProduct + percentOrder) / 2;
                    comboTagGroupOutputModels[i].PointForCombo = Math.Round(avgPercent, 0);
                }
            }
        }


        private void PurchaseProbabilityRatingCalculation(
            List<ComboTagGroupOutputModel> combinations,
            List<FullProductDto> products,
            List<SelectProductForClientOutputModel> allSelectProducts)
        {
            for (int i = 0; i < products.Count; i++)
            {
                int SumOfMatches = 0;

                foreach (ComboTagGroupOutputModel c in combinations)
                {
                    if (c.TagId is null && c.GroupId == products[i].GroupId)
                    {
                        allSelectProducts[i].PurchaseProbability += c.PointForCombo;
                        SumOfMatches += 1;
                    }
                    else if (c.GroupId is null && products[i].Tags.Exists(t => t.Id == c.TagId))
                    {
                        allSelectProducts[i].PurchaseProbability += c.PointForCombo;
                        SumOfMatches += 1;
                    }
                    else if (c.GroupId == products[i].GroupId && products[i].Tags.Exists(t => t.Id == c.TagId))
                    {
                        allSelectProducts[i].PurchaseProbability += c.PointForCombo;
                        SumOfMatches += 1;
                    }
                }

                if (SumOfMatches > 1)
                {
                    allSelectProducts[i].PurchaseProbability = Math.Round(allSelectProducts[i].PurchaseProbability / SumOfMatches,0);
                }
            }
        }

        private List<FullProductDto> SortProductsForClient(int clientId)
        {
            List<FullProductDto> products = new List<FullProductDto>();
            products = _productsRepository.GetFullProducts();
            List<ProductWithScoresAndCommentsDto> reviews = _reviews.GetAllScoresAndCommentsForProductsByClientId(clientId);

            for (int i = products.Count - 1; i >= 0; i--)
            {
                if (products[i].Amount < 1)
                {
                    products.RemoveAt(i);
                }
            }

            for (int j = 0; j < reviews.Count; j++)
            {
                ProductReviewsDto badScore = reviews[j].ProductReviews.Find(s => s.Score < 3);
                if (badScore != null)
                {
                    int i = products.FindIndex(p => p.Id == reviews[j].ProductId);

                    if (i >= 0)
                    {
                        products.RemoveAt(i);
                    }

                }
            }

            return products;
        }

        private double CalcPointForAvgScore(ComboTagGroupDto combo, double pointForCombo)
        {
            double[] limitScoreForCombo = new double[] { 1.9, 2.9, 3.5, 4.5, 5 };
            double[] insertsForComboWithTag = new double[] { -30, -20, 0, 10, 20 };
            double[] insertsForComboWithoutTag = new double[] { -20, -10, 0, 5, 10 };
            double result = -100;
            int j = 0;

            if (combo.TagId is null)
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
