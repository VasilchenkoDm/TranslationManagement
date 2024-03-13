import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ResponseGetListTranslatorModel } from "../models/translator";
import { ApiEndpointHelper } from "../helpers/api-endpoint.helper";
import { ApiEndpointsConstants } from "../constants/api-endpoints.constants";

@Injectable({
    providedIn: 'root'
})
export class TranslatorService {
    constructor(private httpClient: HttpClient) {
    }

    getTranslators(): Observable<ResponseGetListTranslatorModel> {
        return this.httpClient.get<ResponseGetListTranslatorModel>(ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATOR_GET_TRANSLATORS));
    }
}