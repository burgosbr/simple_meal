using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMeal.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string ClientCpf { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int CountPeople { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public Boolean IsFinished { get; set; }
    }
}
