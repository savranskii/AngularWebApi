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
		const formData = new FormData();
		formData.append('login', request.login);
		formData.append('password', request.password);
		formData.append('country', request.country);
		formData.append('province', request.province);

		return this._http.post(API.registration, formData);
	}
}
