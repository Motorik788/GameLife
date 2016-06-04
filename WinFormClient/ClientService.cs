using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Core.Service;
using Core;

namespace Core
{
    public class ClientService : ClientBase<IService>
    {
        public ClientService(string endPointConfigurationName) : base(endPointConfigurationName)
        {

        }
    }
}
