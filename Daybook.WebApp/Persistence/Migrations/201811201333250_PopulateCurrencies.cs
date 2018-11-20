namespace Daybook.WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCurrencies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('AUD', 'Australian dollar')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('CNY', 'Chinese Yuan Renminbi')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('EUR', 'European euro')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('JPY', 'Japanese yen')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('NZD', 'New Zealand dollar')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('TWD', 'New Taiwan dollar')");
            Sql("INSERT INTO usrdata.USRCurrency(CurrencyID, Name) VALUES ('USD', 'United States dollar')");
        }

        public override void Down()
        {
            Sql("DELETE FROM usrdata.USRCurrency");
        }
    }
}
