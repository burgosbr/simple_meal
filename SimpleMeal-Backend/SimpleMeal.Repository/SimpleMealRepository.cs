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

            query = query.OrderByDescending(o => o.Date);

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
                .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId);

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetAllOrderProductsAsyncByOrder(int orderId)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId)
                .Where(op => op.OrderId.Equals(orderId));

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetAllOrderProductsAsyncByProduct(int productId)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.OrderByDescending(op => op.OrderId)
                .Where(op => op.ProductId.Equals(productId));

            return await query.ToArrayAsync();
        }
        public async Task<OrderProduct[]> GetOrderProductsAsyncByStatus(string status)
        {
            IQueryable<OrderProduct> query = _context.OrderProducts
                .Include(op => op.Order)
                .Include(op => op.Product);

            query = query.Where(op => op.Status.ToLower().Equals(status.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
