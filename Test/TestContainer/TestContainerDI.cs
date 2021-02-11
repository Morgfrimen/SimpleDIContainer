using ContainerDI;

using Model;
using Models.DI;

using NUnit.Framework;

namespace TestContainer
{
    // ReSharper disable once InconsistentNaming
    public class TestContainerDI
    {
        private Container _container;

		[SetUp]
		public void Setup()
        {
            _container = Container.GetContainer();
            _container.ClearContainer();
        }

        [Test]
		public void TestRunContainer()
        {
           _container.Regicter<IModel,ModelOne>(new ModelOne() { Name = nameof(ModelOne) });
           IModel models = _container.Resolve<IModel>();
           Assert.AreEqual(models.Name, nameof(ModelOne));
        }

        [Test]
        public void TestContainerTwoObj()
        {
			ModelOne modelOne = new ModelOne() { Name = nameof(ModelOne) };
			ModelsSecond modelTwo = new ModelsSecond() { Name = nameof(ModelsSecond) };
			_container.Regicter<IModel, ModelOne>(modelOne);
			Assert.AreEqual(typeof(ModelOne), _container.Resolve<IModel>().GetType());
            var modelResolveOne = _container.Resolve<IModel>();
            Assert.IsTrue(object.ReferenceEquals(modelOne, modelResolveOne));
            _container.ChangeRecordContainer<IModel, ModelsSecond>(modelTwo);
			var modelResolveTwo = _container.Resolve<IModel>();
            Assert.AreEqual(typeof(ModelsSecond), _container.Resolve<IModel>().GetType());
            Assert.IsTrue(object.ReferenceEquals(modelTwo, modelResolveTwo));
		}
    }
}