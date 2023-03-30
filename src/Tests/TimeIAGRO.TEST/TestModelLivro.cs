using TimeIAGRO.API.Dtos;
using TimeIAGRO.API.Models;
using TimeIAGRO.API.Repositories;

namespace TimeIAGRO.TEST
{
    [TestClass]
    public class TestModelLivro
    {
        [TestMethod]
        public void ValidFrete()
        {            
            double preco = 10;       
            double expected = 2;
            Livro account = new Livro
            {
                Preco = preco,
            };

            double actual = account.CalcularFrete();
            Assert.AreEqual(expected, actual, "Frete não calculado corretamente");
        }
    }
}