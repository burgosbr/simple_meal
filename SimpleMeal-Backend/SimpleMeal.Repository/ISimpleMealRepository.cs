using SimpleMeal.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMeal.Repository
{
    public interface ISimpleMealRepository
    {
        // geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Pedidos
        Task<Order[]> GetAllOrdersAsync();
        Task<Order> GetOrderAsyncById(int orderId);
        Task<Order[]> GetAllOrdersAsyncByClientName(string name);
        Task<Order[]> GetAllOrdersAsyncByStatus(string status);

        // Reservas
        Task<Reservation[]> GetAllReservationsAsync();
        Task<Reservation> GetAllReservationsAsyncBydId(int reservationId);
        Task<Reservation[]> GetAllReservationsAsyncByClientName(string name);
        Task<Reservation[]> GetAllReservationsAsyncByTableNumber(string number);
        Task<Reservation[]> GetAllReservationsAsyncByIsFinished(bool isFinished);

        // Produtos de Pedido
        Task<OrderProduct[]> GetAllOrderProductsAsync();
        Task<OrderProduct[]> GetAllOrderProductsAsyncByOrder(int orderId);
        Task<OrderProduct[]> GetAllOrderProductsAsyncByProduct(int productId);
        Task<OrderProduct[]> GetOrderProductsAsyncByStatus(string status);

        // Produtos
        Task<Product[]> GetAllProductsAsync();
        Task<Product[]> GetProductAsyncByName(string name);
        Task<Product> GetProductAsyncById(int id);
        Task<Product[]> GetAllProductsAsyncByDescrption(string description);
        Task<Product[]> GetAllProductsByStatus(bool status);

        // Mesas
        Task<Table[]> GetAllTablesAsync();
        Task<Table> GetTableByNumber(string number);
        Task<Table[]> GetTableByDescription(string description);
        Task<Table> GetTableById(int id);
        Task<Table[]> GetAllTablesByStatus(bool status);

    }
}