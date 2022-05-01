using Moq;

namespace CaseTechPB.Tests.Mocks
{
    public class MoqBase<TInterface, TInstance> where TInterface : class where TInstance : new()
    {
        protected readonly Mock<TInterface> mock = new();

        public static TInstance Instance()
        {
            return new TInstance();
        }

        public Mock<TInterface> Mock()
        {
           return mock;
        }
    }
}
