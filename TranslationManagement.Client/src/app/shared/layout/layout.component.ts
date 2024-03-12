import { ChangeDetectorRef, Component, OnDestroy } from "@angular/core";
import { MediaMatcher } from '@angular/cdk/layout';

@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnDestroy {

    public mobileQuery: MediaQueryList;

    constructor(private changeDetectorRef: ChangeDetectorRef, 
        private media: MediaMatcher) {
    
        this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        // tslint:disable-next-line: deprecation
        this.mobileQuery.addListener(this._mobileQueryListener);
    }

    private _mobileQueryListener: () => void;

    ngOnDestroy(): void {
        // tslint:disable-next-line: deprecation
        this.mobileQuery.removeListener(this._mobileQueryListener);
    }

}