using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KMC.Northwind.Demo.Tests.Unit.BusinessLogicTest
{
    [TestClass]
    public class SuppliersOperationTests
    {
        private Mock<ISupplierRepository> _mocedSuppliersRepository;        
        private ISupplierOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _mocedSuppliersRepository = new Mock<ISupplierRepository>();
            _sut = new SupplierOperation(_mocedSuppliersRepository.Object);
        }

        [TestMethod]
        public void SupplierOperationTests_WhenFindingSuppliers_Expect_CallRepositoryFindCall_ToBeMade()
        {
            var criteria = new SearchCriteria
            {
                From = 1,
                To = 10,
                SearchTerm = string.Empty
            };
            _sut.FindSuppliers(criteria);

            _mocedSuppliersRepository.Verify(r => r.FindSuppliers(criteria), Times.Once);
        }

        [TestMethod]
        public void SupplierOperationTests_WhenFindingSuppliersById_Expect_CallRepositoryFindByIdCall_ToBeMade()
        {
            var someNumber = 15478;
            _sut.FindSupplierById(someNumber);

            _mocedSuppliersRepository.Verify(r => r.FindSupplierById(someNumber), Times.Once);
        }

        [TestMethod]
        public void SupplierOperationTests_WhenAddingNewSupplier_Expect_RepositoryCallForAddNew_ToBeMade()
        {
            var dummySupplier = new Supplier();
            _sut.CreateSupplier(dummySupplier);

            _mocedSuppliersRepository.Verify(r => r.CreateSupplier(dummySupplier), Times.Once);
        }

        [TestMethod]
        public void SupplierOperationTests_WhenUpdatingNewSupplier_Expect_RepositoryCallForUpdate_ToBeMade()
        {
            var dummySupplier = new Supplier();
            _sut.UpdateSupplier(dummySupplier);

            _mocedSuppliersRepository.Verify(r => r.UpdateSupplier(dummySupplier), Times.Once);
        }

        [TestMethod]
        public void SupplierOperationTests_WhenRemovingSupplier_Expect_RepositoryCallForRemove_ToBeMade()
        {
            var dummySupplier = new Supplier();
            _sut.RemoveSupplier(dummySupplier);

            _mocedSuppliersRepository.Verify(r => r.RemoveSupplier(dummySupplier), Times.Once);
        }
    }
}
