using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using CarAPI.Controllers;
using CarAPI.DAL;
using CarAPI.Models;
using Xunit;

namespace CarAPITest
{
	public class UnitTest1
	{
		[Fact(DisplayName = "Skapa ett företag och ett fordon")]
		public void Test1()
		{
			// In-memory database only exists while the connection is open
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();
			try
			{
				var options = new DbContextOptionsBuilder<CarApiContext>()
					.UseSqlite(connection)
					.Options;

				// Create the schema in the database
				using (var context = new CarApiContext(options))
				{
					context.Database.EnsureCreated();
				}
				using (var context = new CarApiContext(options))
				{
					var companyId = Guid.NewGuid();
					var company = new Company { Id = companyId };
					context.Companies.Add(company);

					var car = new Car() { Id = Guid.NewGuid(), CompanyId = company.Id, VIN = "xxx", RegNr = "ABC123" };
					context.Cars.Add(car);

					context.SaveChanges();
				}

				using (var context = new CarApiContext(options))
				{
					var bc = new CarController(context);
					var result = bc.GetCars();
					Assert.NotNull(result);
					Assert.Equal(result.Count(), 1);
				}

			}
			finally
			{
				connection.Close();
			}
		}
	}
}
