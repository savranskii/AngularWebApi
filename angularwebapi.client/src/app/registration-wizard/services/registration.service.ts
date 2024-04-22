import { Injectable } from '@angular/core';
import { RegistrationRequest } from '../models/RegistrationRequest';
import { HttpClient } from '@angular/common/http';
import { API } from '../../constants/api';

@Injectable({
	providedIn: 'root'
})
export class RegistrationService {
	constructor(private _http: HttpClient) { }

	completeRegistration(request: RegistrationRequest) {
		return this._http.post(API.registration, request);
	}
}
