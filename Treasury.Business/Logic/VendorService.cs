using System;
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
    }
}
