import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Property } from "../Models/Property";
import { Http, RequestOptions, Headers, Response } from "@angular/http";
import { PropertyBackendServices } from "./property-backend.service";


export class HttpBackend extends PropertyBackendServices {

    private addPropertyUrl: string = 'api/property/'
    private getPropertyUrl: string = 'api/property/GetBy/'
    private getPropertiesUrl: string = 'api/property/GetProperties'
    private updatePropertyUrl: string = 'api/property/Updateproperty'
    private deletePropertyUrl: string = 'api/property/DeleteProperty?propertyId='

    private jsonContentOption: RequestOptions;

    constructor(private http: Http) {
        super();
        let headersJson: Headers = new Headers({
            'Content-Type': 'application/json',
        })
        this.jsonContentOption = new RequestOptions({ headers: headersJson })
    }


    addProperty(newProperty: Property): Observable<number> {
        return this.http.post(this.addPropertyUrl, JSON.stringify(newProperty), this.jsonContentOption)
            .map(response => response.json() as number);
    }
    getProperty(id: number): Observable<Property> {
        return this.http.get(this.addPropertyUrl + id, this.jsonContentOption)
            .map(response => response.json());
    }
    getProperties(): Observable<Property[]> {
        return this.http.get(this.addPropertyUrl, this.jsonContentOption)
            .map(response => response.json())
    }
    updateProperty(updateProperty: Property): Observable<number> {
        return this.http.post(this.addPropertyUrl, JSON.stringify(updateProperty), this.jsonContentOption)
            .map(response => response.json() as number);
    }
    deleteProperty(propertyId: Property): Observable<number> {
        return this.http.post(this.addPropertyUrl + propertyId, this.jsonContentOption)
            .map(response => response.json() as number);
    };



}



