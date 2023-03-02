using OfferAggregator.Dal.Repositories;
using AutoMapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using System.Data;
using Dapper;
using System.Text.RegularExpressions;
using System.Linq;


namespace OfferAggregator.Bll
{
    public class AggregatorService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();
        private IAggregatorRepository _aggregatorRepository = new AggregatorRepository();
                
        public List<ComboTagGroupCountProductCountOrderOutputModel> GetGroupTagCountProductsCountOrdersByClientId(int clientId)
        {
            var resultDto = _aggregatorRepository.GetGroupTagCountProductsCountOrdersByClientId(clientId);
            var resultModel = AvgPercentOfCountProductsAndOrders(resultDto);

            return resultModel;
        }

        private List<ComboTagGroupCountProductCountOrderOutputModel> AvgPercentOfCountProductsAndOrders(List<ComboTagGroupCountProductCountOrderDto> combosDtos)
        {
            List<ComboTagGroupCountProductCountOrderOutputModel> result = new();
            if (combosDtos.Count > 0)
            {
                int maxValueProduct = combosDtos.MaxBy(c => c.CountProducts).CountProducts;
                int maxValueOrder = combosDtos.MaxBy(c => c.CountOrders).CountOrders;
                result = combosDtos.Select(c =>
                {
                    int percentProduct = c.CountProducts * 100 / maxValueProduct;
                    int percentOrder = c.CountOrders * 100 / maxValueOrder;
                    int avgPercent = (percentProduct + percentOrder) / 2;

                    var comboModel = new ComboTagGroupCountProductCountOrderOutputModel
                    {
                        Group = _instanceMapper.IMapper.Map<GroupOutputModel>(c.Group),
                        Tag = _instanceMapper.IMapper.Map<TagOutputModel>(c.Tag),
                        AvgPercentOfCountProductsAndOrders = avgPercent
                    };

                    return comboModel;
                }).ToList();
            }

            return result;
        }
    }


}
