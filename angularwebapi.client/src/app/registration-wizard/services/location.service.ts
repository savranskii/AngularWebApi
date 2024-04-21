import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from '../models/Country';
import { API } from '../../constants/api';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  constructor(private _http: HttpClient) { }

	getLocations() {
		return this._http.get<Country[]>(API.locations);
	}
}
