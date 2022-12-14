using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterBusiness
{
    public class ProcessData
    {
        public async Task<List<DebtorModel>> ReadDebtorFileAsync(string filePath)
        {
            List<DebtorModel> debtorList = new List<DebtorModel>();
            StreamReader reader = new StreamReader(filePath);
            bool loop = true;

            while (loop)
            {
                using (reader)
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(",");

                            debtorList.Add(new DebtorModel
                                (
                                    values[0],
                                    Convert.ToInt32(values[1]),
                                    values[2],
                                    values[3],
                                    Convert.ToDouble(values[4]),
                                    values[5],
                                    Convert.ToInt64(values[6]),
                                    values[7],
                                    values[8],
                                    values[9],
                                    values[10]
                                ));
                    }
                }
                loop = false;
            }
            return debtorList;
        }

        public async Task<List<PaymentModel>> ReadPaymentFileAsync(string filePath)
        {
            List<PaymentModel> debtorList = new List<PaymentModel>();
            StreamReader reader = new StreamReader(filePath);
            bool loop = true;

            while (loop)
            {
                using (reader)
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(",");

                        debtorList.Add(new PaymentModel
                            (
                                    values[0],
                                    values[1].ToNullable<double>(),
                                    values[2],
                                    values[3],
                                    values[4],
                                    values[5],
                                    Convert.ToInt32(values[6])
                            ));
                    }
                }
                loop = false;
            }
            return debtorList;
        }

    }
}
