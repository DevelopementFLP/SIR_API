﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GecosIntegrationBrokerService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataProduct", Namespace="http://schemas.datacontract.org/2004/07/GecosWcfIntegrationBroker")]
    public partial class DataProduct : object
    {
        
        private GecosIntegrationBrokerService.DataNamedValue[] ExtraDataField;
        
        private string GrossWeightField;
        
        private long IdField;
        
        private string MosaicCodeField;
        
        private string NetWeightField;
        
        private string ProductCodeField;
        
        private string ProductDescriptionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GecosIntegrationBrokerService.DataNamedValue[] ExtraData
        {
            get
            {
                return this.ExtraDataField;
            }
            set
            {
                this.ExtraDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GrossWeight
        {
            get
            {
                return this.GrossWeightField;
            }
            set
            {
                this.GrossWeightField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MosaicCode
        {
            get
            {
                return this.MosaicCodeField;
            }
            set
            {
                this.MosaicCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NetWeight
        {
            get
            {
                return this.NetWeightField;
            }
            set
            {
                this.NetWeightField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductCode
        {
            get
            {
                return this.ProductCodeField;
            }
            set
            {
                this.ProductCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductDescription
        {
            get
            {
                return this.ProductDescriptionField;
            }
            set
            {
                this.ProductDescriptionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataNamedValue", Namespace="http://schemas.datacontract.org/2004/07/GecosWcfIntegrationBroker")]
    public partial class DataNamedValue : object
    {
        
        private string NameField;
        
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataPallet", Namespace="http://schemas.datacontract.org/2004/07/GecosWcfIntegrationBroker")]
    public partial class DataPallet : object
    {
        
        private long[] BoxesField;
        
        private int CompleteField;
        
        private long IdField;
        
        private string ProductCodeField;
        
        private string ProductDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long[] Boxes
        {
            get
            {
                return this.BoxesField;
            }
            set
            {
                this.BoxesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Complete
        {
            get
            {
                return this.CompleteField;
            }
            set
            {
                this.CompleteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductCode
        {
            get
            {
                return this.ProductCodeField;
            }
            set
            {
                this.ProductCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductDate
        {
            get
            {
                return this.ProductDateField;
            }
            set
            {
                this.ProductDateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreatePalletResult", Namespace="http://schemas.datacontract.org/2004/07/GecosWcfIntegrationBroker")]
    public partial class CreatePalletResult : object
    {
        
        private string DescriptionField;
        
        private string PalletBarCodeLabelField;
        
        private long PalletIdField;
        
        private int ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PalletBarCodeLabel
        {
            get
            {
                return this.PalletBarCodeLabelField;
            }
            set
            {
                this.PalletBarCodeLabelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long PalletId
        {
            get
            {
                return this.PalletIdField;
            }
            set
            {
                this.PalletIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WarehouseIoResult", Namespace="http://schemas.datacontract.org/2004/07/GecosWcfIntegrationBroker")]
    public partial class WarehouseIoResult : object
    {
        
        private string DescriptionField;
        
        private int ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GecosIntegrationBrokerService.IGecosIntegrationBrokerService")]
    public interface IGecosIntegrationBrokerService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/GetProductData", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/GetProductDataResponse")]
        GecosIntegrationBrokerService.DataProduct GetProductData(long id, int[] marelRTypeFilterIn, int[] marelRTypeFilterOut, int[] marelAssignStatusFilterIn, int[] marelAssignStatusFilterOut);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/GetProductData", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/GetProductDataResponse")]
        System.Threading.Tasks.Task<GecosIntegrationBrokerService.DataProduct> GetProductDataAsync(long id, int[] marelRTypeFilterIn, int[] marelRTypeFilterOut, int[] marelAssignStatusFilterIn, int[] marelAssignStatusFilterOut);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/CreatePallet", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/CreatePalletResponse")]
        GecosIntegrationBrokerService.CreatePalletResult CreatePallet(GecosIntegrationBrokerService.DataPallet pallet, int terminal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/CreatePallet", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/CreatePalletResponse")]
        System.Threading.Tasks.Task<GecosIntegrationBrokerService.CreatePalletResult> CreatePalletAsync(GecosIntegrationBrokerService.DataPallet pallet, int terminal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseInput", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseInputResponse")]
        GecosIntegrationBrokerService.WarehouseIoResult NotifyWarehouseInput(long id, long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseInput", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseInputResponse")]
        System.Threading.Tasks.Task<GecosIntegrationBrokerService.WarehouseIoResult> NotifyWarehouseInputAsync(long id, long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseOutput", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseOutputResponse")]
        GecosIntegrationBrokerService.WarehouseIoResult NotifyWarehouseOutput(long id, long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseOutput", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/NotifyWarehouseOutputResponse")]
        System.Threading.Tasks.Task<GecosIntegrationBrokerService.WarehouseIoResult> NotifyWarehouseOutputAsync(long id, long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/getProductsByWarehouse", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/getProductsByWarehouseResponse")]
        long[] getProductsByWarehouse(long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/getProductsByWarehouse", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/getProductsByWarehouseResponse")]
        System.Threading.Tasks.Task<long[]> getProductsByWarehouseAsync(long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/existsProductInWarehouse", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/existsProductInWarehouseRespons" +
            "e")]
        bool existsProductInWarehouse(long id, long idWarehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGecosIntegrationBrokerService/existsProductInWarehouse", ReplyAction="http://tempuri.org/IGecosIntegrationBrokerService/existsProductInWarehouseRespons" +
            "e")]
        System.Threading.Tasks.Task<bool> existsProductInWarehouseAsync(long id, long idWarehouse);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IGecosIntegrationBrokerServiceChannel : GecosIntegrationBrokerService.IGecosIntegrationBrokerService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class GecosIntegrationBrokerServiceClient : System.ServiceModel.ClientBase<GecosIntegrationBrokerService.IGecosIntegrationBrokerService>, GecosIntegrationBrokerService.IGecosIntegrationBrokerService
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public GecosIntegrationBrokerServiceClient() : 
                base(GecosIntegrationBrokerServiceClient.GetDefaultBinding(), GecosIntegrationBrokerServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IGecosIntegrationBrokerService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GecosIntegrationBrokerServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(GecosIntegrationBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), GecosIntegrationBrokerServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GecosIntegrationBrokerServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(GecosIntegrationBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GecosIntegrationBrokerServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(GecosIntegrationBrokerServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GecosIntegrationBrokerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public GecosIntegrationBrokerService.DataProduct GetProductData(long id, int[] marelRTypeFilterIn, int[] marelRTypeFilterOut, int[] marelAssignStatusFilterIn, int[] marelAssignStatusFilterOut)
        {
            return base.Channel.GetProductData(id, marelRTypeFilterIn, marelRTypeFilterOut, marelAssignStatusFilterIn, marelAssignStatusFilterOut);
        }
        
        public System.Threading.Tasks.Task<GecosIntegrationBrokerService.DataProduct> GetProductDataAsync(long id, int[] marelRTypeFilterIn, int[] marelRTypeFilterOut, int[] marelAssignStatusFilterIn, int[] marelAssignStatusFilterOut)
        {
            return base.Channel.GetProductDataAsync(id, marelRTypeFilterIn, marelRTypeFilterOut, marelAssignStatusFilterIn, marelAssignStatusFilterOut);
        }
        
        public GecosIntegrationBrokerService.CreatePalletResult CreatePallet(GecosIntegrationBrokerService.DataPallet pallet, int terminal)
        {
            return base.Channel.CreatePallet(pallet, terminal);
        }
        
        public System.Threading.Tasks.Task<GecosIntegrationBrokerService.CreatePalletResult> CreatePalletAsync(GecosIntegrationBrokerService.DataPallet pallet, int terminal)
        {
            return base.Channel.CreatePalletAsync(pallet, terminal);
        }
        
        public GecosIntegrationBrokerService.WarehouseIoResult NotifyWarehouseInput(long id, long idWarehouse)
        {
            return base.Channel.NotifyWarehouseInput(id, idWarehouse);
        }
        
        public System.Threading.Tasks.Task<GecosIntegrationBrokerService.WarehouseIoResult> NotifyWarehouseInputAsync(long id, long idWarehouse)
        {
            return base.Channel.NotifyWarehouseInputAsync(id, idWarehouse);
        }
        
        public GecosIntegrationBrokerService.WarehouseIoResult NotifyWarehouseOutput(long id, long idWarehouse)
        {
            return base.Channel.NotifyWarehouseOutput(id, idWarehouse);
        }
        
        public System.Threading.Tasks.Task<GecosIntegrationBrokerService.WarehouseIoResult> NotifyWarehouseOutputAsync(long id, long idWarehouse)
        {
            return base.Channel.NotifyWarehouseOutputAsync(id, idWarehouse);
        }
        
        public long[] getProductsByWarehouse(long idWarehouse)
        {
            return base.Channel.getProductsByWarehouse(idWarehouse);
        }
        
        public System.Threading.Tasks.Task<long[]> getProductsByWarehouseAsync(long idWarehouse)
        {
            return base.Channel.getProductsByWarehouseAsync(idWarehouse);
        }
        
        public bool existsProductInWarehouse(long id, long idWarehouse)
        {
            return base.Channel.existsProductInWarehouse(id, idWarehouse);
        }
        
        public System.Threading.Tasks.Task<bool> existsProductInWarehouseAsync(long id, long idWarehouse)
        {
            return base.Channel.existsProductInWarehouseAsync(id, idWarehouse);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IGecosIntegrationBrokerService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IGecosIntegrationBrokerService))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.0.5:8673/GecosIntegrationBrokerService.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return GecosIntegrationBrokerServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IGecosIntegrationBrokerService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return GecosIntegrationBrokerServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IGecosIntegrationBrokerService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IGecosIntegrationBrokerService,
        }
    }
}
