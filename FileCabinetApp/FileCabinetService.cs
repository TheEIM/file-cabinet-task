using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private readonly List<FileCabinetRecord> list = new ();

        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, short acceessLevel, decimal salary, char sex)
        {
            // *Параметр _firstName_ - минимальная длина 2 символа, максимальная длина 60 символов, не равен null, не содержит только пробелы.
            // *Параметр _lastName_ - минимальная длина 2 символа, максимальная длина 60 символов, не равен null, не содержит только пробелы.
            // *Параметр _dateOfBirth_ - минимальная дата 01 - Jan - 1950, максимальная дата -текущая.
            if (firstName.Length < 2 || firstName.Length > 60 || firstName == null)
            {
                throw new ArgumentException("First name is invalid.");
            }
            else if (lastName.Length < 2 || lastName.Length > 60 || lastName == null)
            {
                throw new ArgumentException("Last name is invalid.");
            }
            else if (dateOfBirth < new DateTime(1950, 1, 1) || dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Date of birth is invalid.");
            }
            else if (acceessLevel < 0 || acceessLevel > 100)
            {
                throw new ArgumentException("This level does not existing.");
            }
            else if (salary < 0)
            {
                throw new ArgumentException("Invalid salary value.");
            }
            else if (!(sex.Equals('M') || sex.Equals('W')))
            {
                throw new ArgumentException("This level does not existing.");
            }

            var record = new FileCabinetRecord
            {
                Id = this.list.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                AccessLevel = acceessLevel,
                Salary = salary,
                Sex = char.ToUpper(sex, CultureInfo.InvariantCulture),
            };

            this.list.Add(record);

            return record.Id;
        }

        public FileCabinetRecord[] GetRecords()
        {
            return this.list.ToArray();
        }

        public int GetStat()
        {
            return this.list.Count;
        }
    }
}
