using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IJSE.ARM.DataAccess.DAL;
using IJSE.ARM.Common.Models;
using System.Data.Entity;

using System.Linq;

namespace IJSE.ARM.Test.DALTest
{
    [TestClass]
    public class DALTest
    {
        ARMContext _db = new ARMContext();

        [TestMethod]
        public void ProvinceInsertTest()
        {
            Province province = new Province { Name = "TestProvince" };
            _db.Province.Add(province);
            _db.SaveChanges();

            Province dbProvince = _db.Province.Where(p => p.Name == "TestProvince").FirstOrDefault();

            string actual, expected;

            actual = dbProvince.Name;
            expected = "TestProvince";

            Assert.AreEqual(expected, actual);

        }
    }
}
