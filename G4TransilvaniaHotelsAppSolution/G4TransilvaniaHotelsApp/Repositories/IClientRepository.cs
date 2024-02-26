using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.RepositoriesClient
{
    public interface IClientRepository
    {
        /*Metodos a utilizar en las vistas*/

        /*Crar lista*/
        IEnumerable<ClientModel> GetAll();
        /*Buscar por Id */
        ClientModel GetClientByclientId(int clientId);
        /*Agregar*/
        void add(ClientModel client);
        /*Editar*/
        void Edit(ClientModel client);
        /*Eliminar*/
        void Delete(int clientId);
    }
}
