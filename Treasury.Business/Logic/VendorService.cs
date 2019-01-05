using System;
using System.Collections.Generic;
using System.Linq;
using Treasury.Data;

namespace Treasury.Business.Logic
{
    public class VendorService
    {
        public VendorService()
        {
        }

        public void AddVendor(string vendorName)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Vendors.Add(new Data.Models.Vendor { Name = vendorName });
                db.SaveChanges();
            }
        }

        public IEnumerable<Data.Models.Vendor> GetVendors()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Vendors.Select(x => x).ToList();
            }
        }


    }
}
