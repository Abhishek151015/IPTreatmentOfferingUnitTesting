using IPTreatmentOffering.Controllers;
using IPTreatmentOffering.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IPTreatmentOfferingNUnit
{
    public class Tests
    {
        public List<IPTreatmentPackages> iptreatment = new List<IPTreatmentPackages>
        {
            new IPTreatmentPackages
            {
                AilmentCategory="Orthopaedics",
                TreatmentPackageName="Package_1",
                TestDetails="OPT1, OPT2",
                Cost=2500,
                TreatmentDuration=4
            }
        };
        public List<SpecialistDetail> specialistDetails = new List<SpecialistDetail>
        {
            new SpecialistDetail
            {
                 Name ="Dr. Rohit Sharma",
                 AreaOfExpertise="Orthopaedics",
                 ExperienceInYears=5,
                 ContactNumber="7017325296"
            }
        };
        IPTreatmentPackagesController con1 = new IPTreatmentPackagesController();
        SpecialistDetailController con2 = new SpecialistDetailController();

        [SetUp]
        public void Setup()
        {
            var details = iptreatment.AsQueryable();
            var mockset = new Mock<IPTreatmentPackages>();
            mockset.As<IQueryable<IPTreatmentPackages>>().Setup(m => m.Provider).Returns(details.Provider);
            mockset.As<IQueryable<IPTreatmentPackages>>().Setup(m => m.Expression).Returns(details.Expression);
            mockset.As<IQueryable<IPTreatmentPackages>>().Setup(m => m.ElementType).Returns(details.ElementType);
            mockset.As<IQueryable<IPTreatmentPackages>>().Setup(m => m.GetEnumerator()).Returns(details.GetEnumerator());

            var specialist = specialistDetails.AsQueryable();
            var mockset1 = new Mock<SpecialistDetail>();
            mockset1.As<IQueryable<SpecialistDetail>>().Setup(m => m.Provider).Returns(specialist.Provider);
            mockset1.As<IQueryable<SpecialistDetail>>().Setup(m => m.Expression).Returns(specialist.Expression);
            mockset1.As<IQueryable<SpecialistDetail>>().Setup(m => m.ElementType).Returns(specialist.ElementType);
            mockset1.As<IQueryable<SpecialistDetail>>().Setup(m => m.GetEnumerator()).Returns(specialist.GetEnumerator());
        }

        [Test]
        public void Test1()
        {
            var result = con1.Get();
            var type1 = result;
          // Console.WriteLine(result);

           // Console.WriteLine(iptreatment);

            var type2 = iptreatment as List<IPTreatmentPackages>;
            Assert.IsNotNull(type1);
            Assert.Pass();

        }
        [Test]
        public void Test2()
        {
            var result = con2.Get();
            var type1 = result;
           // Console.WriteLine(result);

           // Console.WriteLine(specialistDetails);

            var type2 = specialistDetails as List<SpecialistDetail>;
            Assert.IsNotNull(type1);
            Assert.Pass();

        }
    }
}