using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SimpleMeal.Domain;

namespace SimpleMeal.Repository
{
    public class SimpleMealRepository : ISimpleMealRepository
    {
        private readonly SimpleMealContext _context;

        public SimpleMealRepository(SimpleMealContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        // Gerais
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Pedidos
        public async Task<Order[]> GetAllOrdersAsync()
        {
            IQueryable<Order> query = _context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Table);

            query = query.AsNoTracking() // forma especifica de não travar o recurso
                .OrderByDescending(o => o.Date);

            return await query.ToArrayAsync();
        }
        public async Task<Order> GetOrderAsyncById(int orderId)
        {
            IQueryable<Order> query = _context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Table);

            query = query.OrderByDescending(o => o.Date)
                .Where(o => o.Id.Equals(orderId));

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Order[]> GetAllOrdersAsyncByClientName(string name)
        {
            IQueryable<Order> query = _context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Table);

            query = query.OrderByDescending(o => o.Date).Where(o => o.ClientName.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Order[]> GetAllOrdersAsyncByStatus(string status)
        {
            IQueryable<Order> query = _context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Table);

            query = query.OrderByDescending(o => o.Date)
                .Where(o => o.Status.ToLower().Contains(status.ToLower()));

            return await query.ToArrayAsync();
        }

        // Reservas
        public async Task<Reservation[]> GetAllReservationsAsync()
        {
            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Table);

            query = query.OrderByDescending(r => r.ScheduleDate);

            return await query.ToArrayAsync();
        }
        public async Task<Reservation> GetAllReservationsAsyncBydId(int reservationId)
        {
            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Table);

            query = query.OrderByDescending(r => r.ScheduleDate)
                .Where(r => r.Id.Equals(reservationId));

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Reservation[]> GetAllReservationsAsyncByClientName(string name)
        {
            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Table);

            query = query.OrderByDescending(r => r.ScheduleDate)
                .Where(r => r.Client.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Reservation[]> GetAllReservationsAsyncByTableNumber(string number)
        {
            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Table);

            query = query.OrderByDescending(r => r.ScheduleDate);

            return await query.ToArrayAsync();
        }
        public async Task<Reservation[]> GetAllReservationsAsyncByIsFinished(bool isFinished)
        {
            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Table);

            query = query.OrderByDescending(r => r.ScheduleDate).Where(r => r.IsFinished.Equals(isFinished));

            return await query.ToArrayAsync();
        }

        // Produtos do pedido
        public async Task<OrderProduct[]> GetAllOrderProductsAsync()
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                // .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId);

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetAllOrderProductsAsyncByOrder(int orderId)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                // .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId)
                .Where(op => op.OrderId.Equals(orderId));

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetAllOrderProductsAsyncByProduct(int productId)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                // .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId)
                .Where(op => op.ProductId.Equals(productId));

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetOrderProductsAsyncByStatus(string status)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                // .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.Where(op => op.Status.ToLower().Equals(status.ToLower()));

            return await query.ToArrayAsync();
        }

        // Produtos
        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = _context.Products;

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetProductAsyncByName(string name)
        {
            IQueryable<Product> query = _context.Products;

            query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductAsyncById(int id)
        {
            IQueryable<Product> query = _context.Products;

            query = query.Where(p => p.Id.Equals(id));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Product[]> GetAllProductsAsyncByDescrption(string description)
        {
            IQueryable<Product> query = _context.Products;

            query = query.Where(p => p.Description.ToLower().Contains(description.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByStatus(bool status)
        {
            IQueryable<Product> query = _context.Products;

            query = query.Where(p => p.IsAvaliable.Equals(status));

            return await query.ToArrayAsync();
        }

        // Mesas
        public async Task<Table[]> GetAllTablesAsync()
        {
            IQueryable<Table> query = _context.Tables;

            return await query.ToArrayAsync();
        }

        public async Task<Table> GetTableByNumber(string number)
        {
            IQueryable<Table> query = _context.Tables;

            query = query.Where(t => t.Number.ToLower().Equals(number.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Table[]> GetTableByDescription(string description)
        {
            IQueryable<Table> query = _context.Tables;

            query = query.Where(t => t.Description.ToLower().Contains(description.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Table> GetTableById(int id)
        {
            IQueryable<Table> query = _context.Tables;

            query = query.Where(t => t.Id.Equals(id));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Table[]> GetAllTablesByStatus(bool status)
        {
            IQueryable<Table> query = _context.Tables;

            query = query.Where(t => t.IsAvaliable.Equals(status));

            return await query.ToArrayAsync();
        }
    }
}
