using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.POCO_s;
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class eRestaurantController
    {
        #region Bills
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        //public List<SpecialEvent> SpecialEvent_List()
        public List<Bill> Bill_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //return context.SpecialEvents.ToList();
                return context.Bills.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        //public SpecialEvent SpecialEventByEventCode(string eventcode)
        public Bill BillByBillID(string billID)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //return context.SpecialEvents.Find(eventcode);
                return context.Bills.Find(billID);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        //public void SepcialEvents_Add(SpecialEvent item)
        public void Bills_Add(Bill item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent added = null;
                //added = context.SpecialEvents.Add(item);
                Bill added = null;
                added = context.Bills.Add(item);
                context.SaveChanges();//not be saved util u call this method
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        //public void Sepcialevents_Update(SpecialEvent item)
        public void Bills_Update(Bill item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State
                // = System.Data.Entity.EntityState.Modified;
                context.Entry<Bill>(context.Bills.Attach(item)).State
                = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        //public void SpecialEvents_Delete(SpecialEvent item)
        public void Bills_Delete(Bill item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent existing = context.SpecialEvents.Find
                // (item.EventCode);
                //context.SpecialEvents.Remove(existing);
                Bill existing = context.Bills.Find(item.BillID);
                context.Bills.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region SpecialEvents
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //return context.SpecialEvents.ToList();
                //get a list of instances for entity using LINQ
                var results = from item in context.SpecialEvents
                               select item;
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialEvent SpecialEventByEventCode(string eventcode)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.SpecialEvents.Find(eventcode);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void SepcialEvents_Add(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent added = null;
                added = context.SpecialEvents.Add(item);
                // commits the add to the database
                // evaluates the annotations (validations) on your entity
                // [Required], [StringLength], [Range],...
                context.SaveChanges();//not be saved util u call this method
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Sepcialevents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State
                = System.Data.Entity.EntityState.Modified;
                //nothing id noy gona happen util your call this method
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent existing = context.SpecialEvents.Find
                (item.EventCode);
                context.SpecialEvents.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Reservations
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> Reservation_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> ReservationbyEvent(string eventcode)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.Where(anItem => anItem.Eventcode == eventcode).ToList();
                //anItem(indicator =>(To Do) anItem.Eventcode == eventcode )
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Reservation ReservationByReservationID(string reservationID)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //return context.SpecialEvents.Find(eventcode);
                return context.Reservations.Find(reservationID);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        //public void Waiters_Add(Waiter item)
        public void Reservations_Add(Reservation item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent added = null;
                //added = context.SpecialEvents.Add(item);
                Reservation added = null;
                added = context.Reservations.Add(item);
                context.SaveChanges();//not be saved util u call this method
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        //public void Waitrs_Update(Waiter item)
        public void Reservations_Update(Reservation item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State
                // = System.Data.Entity.EntityState.Modified;
                context.Entry<Reservation>(context.Reservations.Attach(item)).State
                = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        //public void Waiters_Delete(Waiter item)
        public void Reservations_Delete(Reservation item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent existing = context.SpecialEvents.Find
                // (item.EventCode);
                //context.SpecialEvents.Remove(existing);
                Reservation existing = context.Reservations.Find(item.ReservationID);
                context.Reservations.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Waiters
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Waiters.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter WaiterByWaiterID(string waiterID)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //return context.SpecialEvents.Find(eventcode);
                return context.Waiters.Find(waiterID);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Waiters_Add(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent added = null;
                //added = context.SpecialEvents.Add(item);
                Waiter added = null;
                added = context.Waiters.Add(item);
                context.SaveChanges();//not be saved util u call this method
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiters_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State
                // = System.Data.Entity.EntityState.Modified;
                context.Entry<Waiter>(context.Waiters.Attach(item)).State
                = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiters_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //SpecialEvent existing = context.SpecialEvents.Find
                // (item.EventCode);
                //context.SpecialEvents.Remove(existing);
                Waiter existing = context.Waiters.Find(item.WaiterID);
                context.Waiters.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region LinqQueries
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<CategoryMenuItems> GetCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.MenuCategories
                              orderby cat.Description
                              select new CategoryMenuItems()
                              {
                                  Description = cat.Description,
                                  MenuItems = from item in cat.Items
                                              where item.Active
                                              select new MenuItem()
                                              {
                                                  Description = item.Description,
                                                  Price = item.CurrentPrice,
                                                  Calories = item.Calories,
                                                  Comment = item.Comment
                                              }
                              };
                results.Dump();
            }
        }
        #endregion
    }
}
