
using Practica.Models;
using System.Collections.ObjectModel;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Practica.ViewModels
{
    public class ApiViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        bool _isRunning;
        bool _isEnable;
        string _result;
        ObservableCollection<ApiModel> _rates;

        public string Amount
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }

            set
            {
                if (_isEnable != value)
                {
                    _isEnable = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnable)));
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

        public ObservableCollection<ApiModel> Rates
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

        public ApiModel SourceRate
        {
            get;
            set;
        }

        public ApiModel TargetRate
        {
            get;
            set;
        }

        public ApiViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            try
            {
                IsRunning = true;

                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri("https://api.coinmarketcap.com");

                var controller = "/v1/ticker/";

                var response = await cliente.GetAsync(controller);

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    IsRunning = false;

                    IsEnable = false;

                    await App.Current.MainPage.DisplayAlert("Error", result, "Ok");
                }

                var rates = JsonConvert.DeserializeObject<List<ApiModel>>(result);

                Rates = new ObservableCollection<ApiModel>(rates);

                IsRunning = false;

                IsEnable = true;

                Result = "Listo para convertir";
            }

            catch (Exception ex)
            {
                IsRunning = false;

                IsEnable = false;

                Result = ex.Message;

            } 
        }

        public ICommand ConvertCommand
        {
            get
            {
                return new RelayCommand(Convertir);
            }
        }

        private async void Convertir()
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


            var operacion = amount /
                (decimal)SourceRate.price_usd * (decimal)TargetRate.price_usd;

            Result = string.Format(
                "{0} {1:c2} = {2} {3:c2}",
                SourceRate.symbol,
                amount,
                TargetRate.symbol,
                operacion);
        }

        public ICommand SwitchCommand
        {
            get
            {
                return new RelayCommand(Switchar);
            }
        }

        void Switchar()
        {
            var aux = SourceRate;
            SourceRate = TargetRate;
            TargetRate = aux;
            Convertir();
        }
    }
}
