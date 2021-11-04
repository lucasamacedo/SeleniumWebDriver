using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            // Arrange - dado chrome aberto, página inicial do sistema de leilões
            // dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            // nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            // email
            var inputEmail = driver.FindElement(By.Id("Email"));

            // password
            var inputSenha = driver.FindElement(By.Id("Password"));

            // confirmPassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            // botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Lucas");
            inputEmail.SendKeys("lucas.teste@teste.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            // Act - efetuo o registro
            botaoRegistro.Click();

            // Assert - devo ser redirecionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "lucas.teste@teste.com", "123", "123")]
        [InlineData("Lucas", "lucas", "123", "123")]
        [InlineData("Lucas", "lucas.teste@teste.com", "123", "")]
        [InlineData("Lucas", "lucas.teste@teste.com", "123", "456")]
        public void DadoInfoInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            // Arrange - dado chrome aberto, página inicial do sistema de leilões
            // dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            // nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            // email
            var inputEmail = driver.FindElement(By.Id("Email"));

            // password
            var inputSenha = driver.FindElement(By.Id("Password"));

            // confirmPassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            // botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            // Act - efetuo o registro
            botaoRegistro.Click();

            // Assert - devo ser redirecionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }
    }
}
