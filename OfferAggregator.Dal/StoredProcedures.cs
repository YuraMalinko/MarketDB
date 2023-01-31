namespace OfferAggregator.Dal
{
    public class StoredProcedures
    {
        public const string GetAllManagers = "GetAllManagers";
        public const string AddManager = "AddManager";
        public const string GetSingleManager = "GetSingleManager";
        public const string DeleteManager = "DeleteManager";
        public const string UpdateManager = "UpdateManager";
        public const string AddOrder = "AddOrder";
        public const string DeleteOrder = "DeleteOrder";
        public const string UpdateOrder = "UpdateOrder";
        public const string GetAllOrdersByIdManager = "GetAllOrdersByIdManager";
        public const string GetAllOrdersByClientId = "GetAllOrdersByClientId";
        public const string GetAllOrders = "GetAllOrders";
    }
}