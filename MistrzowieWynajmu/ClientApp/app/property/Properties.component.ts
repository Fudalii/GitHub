import { Component, OnInit } from "@angular/core";
import { Injectable } from "@angular/core";
import { Property } from "../Models/Property";
import { PropertiesService } from "./services/PropertiesService";

@Component(
    {
        templateUrl: './properties.component.html'
    }
)

export class PropertiesComponent implements OnInit {


    constructor(private propertiesService: PropertiesService) {

    }


    ngOnInit(): void {

        let testowaZmienna = 'Testowa Zmienna'

        this.propertiesService.getProperties().subscribe(prop => console.log(prop))
    }





}


