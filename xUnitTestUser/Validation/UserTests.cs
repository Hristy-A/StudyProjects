using Model;
using System;
using Xunit;

namespace xUnitTestUser.Validation
{
    public class UserTests
    {
        [Theory]
        [InlineData("ivan.maharin@yandex.ru", "Ivan", "Maharin", "Ivan.Maharin@yandex.ru")]
        [InlineData("lio_ten_do.baradiq@gmail.com", "Lio ten do", "Baradiq", "Lio_ten_do.Baradiq@gmail.com")]
        [InlineData("ZaRaZa.PISHU_KAPSOM@mail.ru", "Zaraza", "Pishu kapsom", "Zaraza.Pishu_kapsom@mail.ru")]
        [InlineData("ONLY.KAPS@yandex.ru", "Only", "Kaps", "Only.Kaps@yandex.ru")]
        public void TestCorrectEmail(string email, string name, string lastName, string expectingEmail)
        {
            User user = new User(email);
            Assert.Contains(name, user.Name);
            Assert.Contains(lastName, user.LastName);
            Assert.Contains(expectingEmail, user.Email);
        }

        [Theory]
        [InlineData("-.-@test.ru")]
        [InlineData("a.g@test.ru")]
        [InlineData("anton.basaktest.ru")]
        [InlineData("saransky@lavoren.de")]
        [InlineData("samodelkin@mail.ru")]
        public void TestThrowExcEmail(string email)
        {
            Assert.Throws(typeof(UserException), delegate() { User user = new User(email); });
            //Theory method 'TestThrowExcEmail' on test class 'UserTests' has InlineData duplicate(s). ??? Не понимаю, что означает данное предупреждение
            //Do not use typeof() expression to check the exception type. ??? Предупреждение, с сообщением не использовать typeof. А по другому сделать тест у меня не получилось :)
        }

        [Theory]
        [InlineData("Yuliya", "Napushina", "Yuliya.Napushina@mail.com", "Yuliya", "Napushina")]
        [InlineData("VlAdiMIR", "Sort", "Vladimir.Sort@mail.com", "Vladimir", "Sort")]
        [InlineData("Mahao-De-Vanichi", "Mahlupest", "Mahao_de_vanichi.Mahlupest@mail.com", "Mahao de vanichi", "Mahlupest")]
        [InlineData("Mao_DZa_Li", "Neo", "Mao_Dza_Li.Neo@mail.com", "Mao_Dza_Li", "Neo")] // этот тест должен свалиться,
                                                                                          // чтобы показать, что символ "_"
                                                                                          // в имени использовтаь нельзя))
                                                                                          // (если конечно я правильно понял)
        [InlineData("TAMAKO-TI-YANI", "ZAMA", "Tamako_ti_yani.Zama@mail.com", "Tamako ti yani", "Zama")]
        public void TestCorrectNaming(string name, string lastName, string email,
             string expectingName, string expectingLastName)
        {
            User user = new User(name, lastName);
            Assert.Contains(email, user.Email);
            Assert.Contains(expectingName, user.Name);
            Assert.Contains(expectingLastName, user.LastName);
        }

        [Theory]
        [InlineData("Samana_de", "Marioni")]
        [InlineData("Mi", "N")]
        [InlineData("David1", "Saranov")]
        // Any test :)
        public void TestThrowExcNaming(string name, string lastName)
        {
            Assert.Throws(typeof(UserException), delegate () { User user = new User(name, lastName); });
            //То же самое предупреждение(
        }
    }
}
