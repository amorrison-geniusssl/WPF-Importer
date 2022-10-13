using ImporterBusiness;
using ImporterDomain.Models;
using ImporterUI.Commands;
using ImporterUI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace ImporterUI.ViewModels
{
    public class PaymentsViewModel : ValidationViewModelBase
    {
        private IPaymentRespository _paymentRepository;
        private PaymentItemViewModel? _selectedPayment;

        public PaymentsViewModel(IPaymentRespository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public ObservableCollection<PaymentItemViewModel> Payments { get; } = new();


        public override async Task LoadAsync()
        {
            Payments.Clear();

            var payments = await _paymentRepository.GetAllAsync();
            if (payments != null)
            {
                foreach (var payment in payments)
                {

                    Payments.Add(new PaymentItemViewModel(payment));
                }
            }
            CanInsert = false;
        }

        public override async Task LoadFileAsync(string filePath)
        {
            ProcessData file = new ProcessData();
            List<PaymentModel> payments = new List<PaymentModel>();

            try
            {
                payments = await file.ReadPaymentFileAsync(filePath);
                CanInsert = true;
            }
            catch (Exception)
            {
                var dg = new Action(() => { MessageBox.Show("Invalid Data:= Please enter a csv file with the correct Payment fields"); });
                Dispatcher.CurrentDispatcher.BeginInvoke(dg);
                return;
            }

            Payments.Clear();

            if (Payments != null)
            {
                foreach (var payment in payments)
                {
                    var newPayment = new PaymentItemViewModel
                    (
                            payment.AdeptRef,
                            payment.Amount,
                            payment.EffectiveDate,
                            payment.Source,
                            payment.Method,
                            payment.Comment,
                            payment.AccountNumber

                    );

                    Payments.Add(newPayment);
                }
            }

        }

        public override async Task InsertData()
        {
            foreach (var item in Payments)
            {
                if (!item.HasErrors)
                {
                    _paymentRepository.Add(new PaymentModel
                        (
                            item.AdeptRef,
                            item.Amount,
                            item.EffectiveDate,
                            item.Source,
                            item.Method,
                            item.Comment,
                            item.AccountNumber
                        ));
                }
            }
            await _paymentRepository.SaveAsync();
        }


        public PaymentItemViewModel? SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                _selectedPayment = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsPaymentSelected));
            }
        }

        public bool IsPaymentSelected
        {
            get
            {
                return SelectedPayment != null;
            }
        }

    }
}
