import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiEndpointsConstants } from "../constants/api-endpoints.constants";
import { ApiEndpointHelper } from "../helpers/api-endpoint.helper";
import { ResponseGetListTranslationJobModel } from "../models/translation-job";

@Injectable({
    providedIn: 'root'
})
export class TranslationJobService {
    constructor(private httpClient: HttpClient) {
    }

    getJobs(): Observable<ResponseGetListTranslationJobModel> {
        return this.httpClient.get<ResponseGetListTranslationJobModel>(ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_GET_JOBS));
    }
}