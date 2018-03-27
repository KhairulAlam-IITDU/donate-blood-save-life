using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class BloodBankRepository
    {
        DBSLEntities myOnlineBloodDonorEntities = null;

        public BloodBankRepository()
        {
            myOnlineBloodDonorEntities = new DBSLEntities();
        }

        public bool AddBloodBank(BloodBank bloodBank)
        {
            myOnlineBloodDonorEntities.BloodBanks.Add(bloodBank);
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool EditBloodBank(BloodBank bloodBank)
        {
            myOnlineBloodDonorEntities.BloodBanks.Attach(bloodBank);
            myOnlineBloodDonorEntities.Entry(bloodBank).State = System.Data.Entity.EntityState.Modified;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool DeleteBloodBank(BloodBank bloodBank)
        {
            myOnlineBloodDonorEntities.BloodBanks.Attach(bloodBank);
            myOnlineBloodDonorEntities.Entry(bloodBank).State = System.Data.Entity.EntityState.Deleted;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public List<BloodBank> GetBloodBankList()
        {
            return myOnlineBloodDonorEntities.BloodBanks.ToList();
        }

        public List<BloodBank> GetBloodBankListByUserName(String bloodbankname)
        {
            return myOnlineBloodDonorEntities.BloodBanks.Where( b => b.UserName == bloodbankname).ToList();
        }
        public BloodBank GetBloodBankByBloodBankUserName(String bloodBankname)
        {
            return myOnlineBloodDonorEntities.BloodBanks.FirstOrDefault(u => u.UserName == bloodBankname);
        }

        public BloodBank GetBloodBankByUserNameAndPassword(string username, string password)
        {
            return myOnlineBloodDonorEntities.BloodBanks.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public bool Validuser(string username, string password)
        {
            return myOnlineBloodDonorEntities.BloodBanks.Count(u => u.UserName == username && u.Password == password) > 0;
        }
    }
}
