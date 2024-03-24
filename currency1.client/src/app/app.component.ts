import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Currency {
  name: string;
  value: string;
}

interface RatesModel {
  amount: number;
  from: string;
  to: string;
  date: string;
}

interface RatesResponse {
  value: number;
  errors: string[];
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public exchangeTo: Currency[] = [];
  public exchangeFrom: Currency[] = [];
  
  public selectedFrom: string = "EUR";
  public selectedTo: string = "USD";//TO DO: remove currency when selected
  public touched: boolean = false;

  public amount: number = 10;
  public rate: number | null = null;
  public date: string | null = "2024-02-28";
  public errors: string[] | null = [];
  constructor(private http: HttpClient) { }

  ngOnInit() {
    if (this.exchangeTo.length <= 0)
      this.getCurrencies();
  }

  getCurrencies() {
    this.http.get<Currency[]>('currency').subscribe(
      (result) => {
        this.exchangeTo = result;
        this.exchangeFrom = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  calculateRate() {
    this.touched = true;
    if (this.amount <= 0 || !this.selectedFrom || !this.selectedTo)
      return;
    const model = { amount: this.amount, from: this.selectedFrom, to: this.selectedTo, date: this.date } as RatesModel;
    this.http.post<RatesResponse>('currency', model).subscribe(
      (result) => {
        this.rate = result.value;
        this.errors = result.errors;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'currency1.client';
}
