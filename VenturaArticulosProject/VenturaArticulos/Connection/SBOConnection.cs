using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaArticulos.Connection
{
    class SBOConnection
    {
        #region _Attributes_

        private SAPbobsCOM.Company oCompany;
        private SAPbobsCOM.Recordset oRecordSet;
        private bool bConnected;
        private int errorCode, iResult;
        private string errorMessage;

        #endregion

        #region _Constructor_

        public SBOConnection()
        {
            oCompany = null;
            oRecordSet = null;
            bConnected = false;
        }

        #endregion

        #region _Properties_

        public SAPbobsCOM.Recordset companyList
        {
            get
            {
                return oRecordSet;
            }
        }
        public SAPbobsCOM.Company companyObject
        {
            get
            {
                return oCompany;
            }
        }
        public bool IsConnected
        {
            get
            {
                return bConnected;
            }
        }

        #endregion

        #region _Methods_

        
      
        public void ConnectCompany(int DBType, string Server, string LicenseServer, string UserDB, string PassDB, string UserB1, string PassB1, string CompanyDB, out string strMessage)
        {
            strMessage = string.Empty;
            bConnected = false;
            try
            {
                
                var TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017;

                if (DBType != 0)
                    TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_HANADB;

                oCompany = new SAPbobsCOM.Company
                {
                    DbServerType = TipoServidor,

                    Server = Server.ToString(),
                    LicenseServer = LicenseServer.ToString(),
                    language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La,
                    UseTrusted = false,
                    DbUserName = UserDB.ToString(),
                    DbPassword = PassDB.ToString(),
                    UserName = UserB1.ToString(),
                    Password = PassB1.ToString(),
                    CompanyDB = CompanyDB.ToString()
                };

                iResult = oCompany.Connect();

                if (iResult != 0)
                {
                    oCompany.GetLastError(out errorCode, out errorMessage);
                    strMessage = "[" + errorCode + "] " + errorMessage;
                }
                else
                {
                    bConnected = true;
                }
            }
            catch (Exception Ex)
            {
                strMessage = Ex.Message;
            }
        }
      

        #endregion
    }

}
