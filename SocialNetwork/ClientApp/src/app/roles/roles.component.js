"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const roles_service_1 = require("../services/roles.service");
const router_1 = require("@angular/router");
let RolesComponent = class RolesComponent {
    constructor(rolesService, _route) {
        this.rolesService = rolesService;
        this._route = _route;
        this.roles = [];
        this.userRoles = [];
    }
    ngOnInit() {
        this.rolesService.getRoles().subscribe(result => this.roles = result);
        this._route.params.subscribe(params => {
            this.id = params['id'];
            this.getRolesByUserId(this.id);
        });
    }
    getRolesByUserId(id) {
        this.rolesService.getRolesByUserId(id).subscribe(result => this.userRoles = result);
    }
    onSubmit(roleForm) {
        let selectedRoles = [];
        Object.keys(roleForm.controls).forEach(key => {
            if (roleForm.controls[key].value) {
                selectedRoles.push(key);
            }
        });
        this.rolesService.updateUserRoles(this.id, selectedRoles).subscribe(() => alert("Succesfully saved"));
    }
    isAnySelected(roleForm) {
        return !Object.keys(roleForm.controls).some(key => roleForm.controls[key].value);
    }
};
RolesComponent = __decorate([
    core_1.Component({
        selector: 'app-roles',
        templateUrl: './roles.component.html'
    }),
    __metadata("design:paramtypes", [roles_service_1.RolesService, router_1.ActivatedRoute])
], RolesComponent);
exports.RolesComponent = RolesComponent;
//# sourceMappingURL=roles.component.js.map