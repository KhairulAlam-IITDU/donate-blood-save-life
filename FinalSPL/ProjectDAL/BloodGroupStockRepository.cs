using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class BloodGroupStockRepository
    {

        DBSLEntities myOnlineBloodDonorEntities = null;

        public BloodGroupStockRepository()
        {
            myOnlineBloodDonorEntities = new DBSLEntities();
        }

        public bool AddBloodGroupStock(BloodGroupStock bloodGroupStock)
        {
            myOnlineBloodDonorEntities.BloodGroupStocks.Add(bloodGroupStock);
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool EditBloodGroupStock(BloodGroupStock bloodGroupStock)
        {
            myOnlineBloodDonorEntities.BloodGroupStocks.Attach(bloodGroupStock);
            myOnlineBloodDonorEntities.Entry(bloodGroupStock).State = System.Data.Entity.EntityState.Modified;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool DeleteBloodGroupStock(BloodGroupStock bloodGroupStock)
        {
            myOnlineBloodDonorEntities.BloodGroupStocks.Attach(bloodGroupStock);
            myOnlineBloodDonorEntities.Entry(bloodGroupStock).State = System.Data.Entity.EntityState.Deleted;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public List<BloodGroupStock> GetBloodGroupStockList()
        {
            return myOnlineBloodDonorEntities.BloodGroupStocks.ToList();
        }

        public List<BloodGroupStock> GetBloodGroupStockListByBloodBankUserName(String username)
        {
            return myOnlineBloodDonorEntities.BloodGroupStocks.Where( bg => bg.BBUsername == username).ToList();
        }

        public BloodGroupStock GetBloodGroupStockByBloodGroupStockId(int bloodGroupStockId)
        {
            return myOnlineBloodDonorEntities.BloodGroupStocks.FirstOrDefault(u => u.Id == bloodGroupStockId);
        }

        public IQueryable<BloodGroupStock> GetBloodBankStockByBloodBankUserName(string username)
        {
            return myOnlineBloodDonorEntities.BloodGroupStocks.Where(u => u.BBUsername == username);
        }

        public BloodGroupStock GetBloodBankByBloodBankUserName(string name)
        {
            return myOnlineBloodDonorEntities.BloodGroupStocks.FirstOrDefault(u => u.BBUsername == name);
        }

        
    }
}
