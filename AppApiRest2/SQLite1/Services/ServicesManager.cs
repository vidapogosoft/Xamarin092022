using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite1.DTO;
using SQLite1.Interface;

namespace SQLite1.Services
{
    public class ServicesManager
    {

        IRestService restService;

        public ServicesManager(IRestService service)
        {
            restService = service;
        }

        public async Task<int> SaveRegistro(DTORegistrado item, bool isNewItem)
        {
            int Grabado;

            Grabado = await restService.SaveRegistro(item, isNewItem);

            return Grabado;
        }


    }
}
