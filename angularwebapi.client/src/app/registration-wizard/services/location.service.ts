import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Country} from '../models/Country';
import {API} from '../../constants/api';
import {Province} from '../models/Province';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  constructor(private _http: HttpClient) {
  }

  getCountries() {
    return this._http.get<Country[]>(API.countries);
  }

  getProvinces(countryId: number) {
    return this._http.get<Province[]>(API.provinces.replace('{id}', countryId.toString()));
  }
}
