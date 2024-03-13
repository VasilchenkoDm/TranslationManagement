import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiEndpointsConstants } from "../constants/api-endpoints.constants";
import { ApiEndpointHelper } from "../helpers/api-endpoint.helper";

@Injectable({
    providedIn: 'root'
})
export class TranslationJobService {
    constructor(private httpClient: HttpClient) {
    }

    getJobs(): Observable<any> {
        return this.httpClient.get<any>(ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_GET_JOBS));
    }
}