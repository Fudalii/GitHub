import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Property } from "../../Models/Property";
import { PropertyBackendServices } from "../../services/property-backend.service";
import { HttpBackend } from "../../services/http-backend";

@Injectable()
export class PropertiesService {

    constructor(private backend: PropertyBackendServices) { }

    addProperty(property: Property): Observable<number> {
        return this.backend.addProperty(property)
    }

    getProperty(id: number): Observable<Property> {
        return this.backend.getProperty(id);
    }

    getProperties(): Observable<Property[]> {
        return this.backend.getProperties();
    }

    updateProperty(updateProperty: Property): Observable<number> {
        return this.backend.updateProperty(updateProperty);
    }

    deleteProperty(propertyId: Property): Observable<number> {
        return this.backend.deleteProperty(propertyId);
    };


}