
using Practica.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Practica.ViewModels
{
    public class ExchangeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

#region Atributos

        bool _isRunning;
        bool _isEnabled;
        string _result;
        ObservableCollection<ExchangeModel> _rates;

#endregion

        #region Propiedades
        public string Amount
        {
            get;
            set;
        }

        public ObservableCollection<ExchangeModel> Rates
        {
            get
            {
                return _rates;
            }
            set
            {
                if (_rates != value)
                {
                    _rates = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Rates)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }

            set
            {
                if (_result != value)
                {
                    _result = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        public ExchangeModel SourceRate { get; set; }

        public ExchangeModel TargetRate { get; set; }

#endregion

        public ExchangeViewModel()
        {
            LoadRates();
        }

#region Metodos

        async void LoadRates()
        {
            IsRunning = true;

            Result = "Cargando Tasas...";

            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri("http://apiexchangerates.azurewebsites.net");

                var controller = "/api/Rates";

                var response = await client.GetAsync(controller);

                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    IsRunning = false;

                    Result = result;
                }

                var rates = JsonConvert.DeserializeObject<List<ExchangeModel>>(result);

                Rates = new ObservableCollection<ExchangeModel>(rates);

                IsRunning = false;

                IsEnabled = true;

                Result = "Listo para convertir";
            }
            catch (Exception ex)
            {
                IsRunning = false;

                _isEnabled = false;

                Result = ex.Message;

                LoadRates();
            }
        }

        public ICommand ConvertCommand
        {
            get
            {
                return new RelayCommand(Convertir);
            }
        }

        async void Convertir()
        {
            if (string.IsNullOrEmpty(Amount))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un monto.",
                    "Aceptar");

                return;
            }

            decimal amount = 0;

            if (!decimal.TryParse(Amount, out amount))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un valor en numeros.",
                    "Aceptar");

                return;
            }

            if (SourceRate == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe seleccionar una tasa de origen.",
                    "Aceptar");

                return;
            }

            if (TargetRate == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe seleccionar una tasa de destino.",
                    "Aceptar");

                return;
            }

            var MontoAConvertir = amount /
                (decimal)SourceRate.TaxRate *
                (decimal)TargetRate.TaxRate;

            Result = string.Format(
                "{0} {1:c2} = {2}, {3:c2}",
                SourceRate.Code, 
                amount, 
                TargetRate.Code, 
                MontoAConvertir);
        }

        public ICommand SwitchCommand
        {
            get
            {
                return new RelayCommand(Switche);
            }
        }
        //Invertir
        void Switche()
        {
            var auxx = SourceRate;
            SourceRate = TargetRate;
            TargetRate = auxx;
            Convertir();
        }
        #endregion
    }
}
