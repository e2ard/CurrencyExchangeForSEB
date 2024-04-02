using Currency1.Server.Models;
using Currency1.Server.Services;
using CurrencyStore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverterTests
{
    public class MiscTests
    {
        ICurrencyService service = new CurrencyRequestService();
        [Fact]
        public async void GetResponseTest()
        {
            var url = "https://data-api.ecb.europa.eu/service/data/EXR/M..EUR.SP00.A?updatedAfter=2024-02-28T14%3A15%3A00%2B01%3A00&detail=dataonly&format=jsondata"; // ECB API URL
            var FakeResponse = @"{
    'header': {
        'id': '1832b7ed-e9c1-4f7a-95aa-0c4d147d097c',
        'test': false,
        'prepared': '2024-03-19T19:21:22.816+01:00',
        'sender': {
            'id': 'ECB'
        }
},
    'dataSets': [
        {
            'action': 'Replace',
            'validFrom': '2024-03-19T19:21:22.816+01:00',
            'series': {
                '0:0:0:0:0': {
                    'observations': {
                        '0': [
                            1.6533380952381
                        ]
                    }
                },
                '0:1:0:0:0': {
    'observations': {
        '0': [
                            1.9558
                        ]
                    }
},
                '0:2:0:0:0': {
    'observations': {
        '0': [
                            5.3559142857143
                        ]
                    }
},
                '0:3:0:0:0': {
    'observations': {
        '0': [
                            1.4564428571429
                        ]
                    }
},
                '0:4:0:0:0': {
    'observations': {
        '0': [
                            0.946219047619
                        ]
                    }
},
                '0:5:0:0:0': {
    'observations': {
        '0': [
                            7.7650619047619
                        ]
                    }
},
                '0:6:0:0:0': {
    'observations': {
        '0': [
                            25.2320476190476
                        ]
                    }
},
                '0:7:0:0:0': {
    'observations': {
        '0': [
                            7.4549904761905
                        ]
                    }
},
                '0:8:0:0:0': {
    'observations': {
        '0': [
                            0.8546623809524
                        ]
                    }
},
                '0:9:0:0:0': {
    'observations': {
        '0': [
                            8.4432047619048
                        ]
                    }
},
                '0:10:0:0:0': {
    'observations': {
        '0': [
                            388.0390476190476
                        ]
                    }
},
                '0:11:0:0:0': {
    'observations': {
        '0': [
                            16898.593333333327
                        ]
                    }
},
                '0:12:0:0:0': {
    'observations': {
        '0': [
                            3.9345476190476
                        ]
                    }
},
                '0:13:0:0:0': {
    'observations': {
        '0': [
                            89.560819047619
                        ]
                    }
},
                '0:14:0:0:0': {
    'observations': {
        '0': [
                            148.6809523809524
                        ]
                    }
},
                '0:15:0:0:0': {
    'observations': {
        '0': [
                            161.3771428571428
                        ]
                    }
},
                '0:16:0:0:0': {
    'observations': {
        '0': [
                            1437.3742857142856
                        ]
                    }
},
                '0:17:0:0:0': {
    'observations': {
        '0': [
                            18.4425
                        ]
                    }
},
                '0:18:0:0:0': {
    'observations': {
        '0': [
                            5.1467666666667
                        ]
                    }
},
                '0:19:0:0:0': {
    'observations': {
        '0': [
                            11.3842857142857
                        ]
                    }
},
                '0:20:0:0:0': {
    'observations': {
        '0': [
                            1.7617666666667
                        ]
                    }
},
                '0:21:0:0:0': {
    'observations': {
        '0': [
                            60.4860952380952
                        ]
                    }
},
                '0:22:0:0:0': {
    'observations': {
        '0': [
                            4.325580952381
                        ]
                    }
},
                '0:23:0:0:0': {
    'observations': {
        '0': [
                            4.974619047619
                        ]
                    }
},
                '0:24:0:0:0': {
    'observations': {
        '0': [
                            11.249980952381
                        ]
                    }
},
                '0:25:0:0:0': {
    'observations': {
        '0': [
                            1.4513428571429
                        ]
                    }
},
                '0:26:0:0:0': {
    'observations': {
        '0': [
                            38.7094761904762
                        ]
                    }
},
                '0:27:0:0:0': {
    'observations': {
        '0': [
                            33.264380952381
                        ]
                    }
},
                '0:28:0:0:0': {
    'observations': {
        '0': [
                            1.0794714285714
                        ]
                    }
},
                '0:29:0:0:0': {
    'observations': {
        '0': [
                            20.5081904761905
                        ]
                    }
}
            }
        }
    ],
    'structure': {
    'links': [
            {
        'title': 'Exchange Rates',
                'rel': 'dataflow',
                'href': 'http://data-api.ecb.europa.eu:80/service/dataflow/ECB/EXR/1.0'
            }
        ],
        'name': 'Exchange Rates',
        'dimensions': {
        'series': [
                {
            'id': 'FREQ',
                    'name': 'Frequency',
                    'values': [
                        {
                'id': 'M',
                            'name': 'Monthly'
                        }
                    ]
                },
                {
            'id': 'CURRENCY',
                    'name': 'Currency',
                    'values': [
                        {
                'id': 'AUD',
                            'name': 'Australian dollar'
                        },
                        {
                'id': 'BGN',
                            'name': 'Bulgarian lev'
                        },
                        {
                'id': 'BRL',
                            'name': 'Brazilian real'
                        },
                        {
                'id': 'CAD',
                            'name': 'Canadian dollar'
                        },
                        {
                'id': 'CHF',
                            'name': 'Swiss franc'
                        },
                        {
                'id': 'CNY',
                            'name': 'Chinese yuan renminbi'
                        },
                        {
                'id': 'CZK',
                            'name': 'Czech koruna'
                        },
                        {
                'id': 'DKK',
                            'name': 'Danish krone'
                        },
                        {
                'id': 'GBP',
                            'name': 'UK pound sterling'
                        },
                        {
                'id': 'HKD',
                            'name': 'Hong Kong dollar'
                        },
                        {
                'id': 'HUF',
                            'name': 'Hungarian forint'
                        },
                        {
                'id': 'IDR',
                            'name': 'Indonesian rupiah'
                        },
                        {
                'id': 'ILS',
                            'name': 'Israeli shekel'
                        },
                        {
                'id': 'INR',
                            'name': 'Indian rupee'
                        },
                        {
                'id': 'ISK',
                            'name': 'Iceland krona'
                        },
                        {
                'id': 'JPY',
                            'name': 'Japanese yen'
                        },
                        {
                'id': 'KRW',
                            'name': 'Korean won (Republic)'
                        },
                        {
                'id': 'MXN',
                            'name': 'Mexican peso'
                        },
                        {
                'id': 'MYR',
                            'name': 'Malaysian ringgit'
                        },
                        {
                'id': 'NOK',
                            'name': 'Norwegian krone'
                        },
                        {
                'id': 'NZD',
                            'name': 'New Zealand dollar'
                        },
                        {
                'id': 'PHP',
                            'name': 'Philippine peso'
                        },
                        {
                'id': 'PLN',
                            'name': 'Polish zloty'
                        },
                        {
                'id': 'RON',
                            'name': 'Romanian leu'
                        },
                        {
                'id': 'SEK',
                            'name': 'Swedish krona'
                        },
                        {
                'id': 'SGD',
                            'name': 'Singapore dollar'
                        },
                        {
                'id': 'THB',
                            'name': 'Thai baht'
                        },
                        {
                'id': 'TRY',
                            'name': 'Turkish lira'
                        },
                        {
                'id': 'USD',
                            'name': 'US dollar'
                        },
                        {
                'id': 'ZAR',
                            'name': 'South African rand'
                        }
                    ]
                },
                {
            'id': 'CURRENCY_DENOM',
                    'name': 'Currency denominator',
                    'values': [
                        {
                'id': 'EUR',
                            'name': 'Euro'
                        }
                    ]
                },
                {
            'id': 'EXR_TYPE',
                    'name': 'Exchange rate type',
                    'values': [
                        {
                'id': 'SP00',
                            'name': 'Spot'
                        }
                    ]
                },
                {
            'id': 'EXR_SUFFIX',
                    'name': 'Series variation - EXR context',
                    'values': [
                        {
                'id': 'A',
                            'name': 'Average'
                        }
                    ]
                }
            ],
            'observation': [
                {
            'id': 'TIME_PERIOD',
                    'name': 'Time period or range',
                    'role': 'time',
                    'values': [
                        {
                'id': '2024-02',
                            'name': '2024-02',
                            'start': '2024-02-01T00:00:00.000+01:00',
                            'end': '2024-02-29T23:59:59.999+01:00'
                        }
                    ]
                }
            ]
        }
}
}";//used to mockup request

            //var service = new CurrencyRequestService();
            var response = await service.GetRates(url);
            var currencyNames = response!.structure!.dimensions!.series![1].values.ToList();
            var currencyExchangeRates = response!.dataSets![0].series!.Values.Select(s => s.observations!["0"].FirstOrDefault()).ToList();

            Assert.NotNull(currencyExchangeRates);
            Assert.NotNull(currencyNames);
            Assert.Equal(currencyExchangeRates.Count, currencyNames.Count);
        }

        private const string webApiUrl = "http://localhost:5016/";
        [Fact]
        public async void GetCurrenciesTest()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync($"{webApiUrl}currencies");
                var curencies = JsonConvert.DeserializeObject<List<StoredCurrency>>(result);
                Assert.NotNull(curencies);
                Assert.Equal(30, curencies.Count);
            }
        }

        [Theory]
        [InlineData(3, 0, null, null)]
        [InlineData(2, 0, null, "EUR")]
        [InlineData(1, 0, "EUR", "EUR")]
        [InlineData(0, 1, "EUR", "EUR")]//TO fix: more specific tests to identify issues faster
        public void RatesModelValidationTest(int eurCount, decimal amount, string exchageFrom, string exchangeTo)
        {
            var rates = new RatesModel() { Amount = amount, From = exchageFrom, To = exchangeTo };
            var errors = rates.Validate(new ValidationContext(rates, null, null));
            Assert.Equal(eurCount, errors.Count());
        }
    }
}