using Online.Shopping.Application.Customers.Create;

namespace Online.Shopping.Tests
{
    public class CustomerIntegrationTests : BaseIntegrationTest
    {
        public CustomerIntegrationTests(IntegrationTestFactory integrationTestFactory) : base(integrationTestFactory)
        {
        }

        #region Positive Testing

        [Fact]
        public async Task CreateCustomer_ShouldReturnCustomerId_IfSuccessful()
        {
            // Given
            var createCustomerCommand = new CreateCustomerCommand("Evert", "Botha", "@.@.com");

            // When
            var createCustomerResponse = await Sender.Send(createCustomerCommand);

            // Then 
            Assert.NotNull(createCustomerResponse);
            Assert.IsType<CreateCustomerResponse>(createCustomerResponse);
        }

        #endregion

    }
}
