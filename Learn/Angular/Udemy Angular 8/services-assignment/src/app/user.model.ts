export enum UserStatus {
  active,
  inactive
}

export class User {
  constructor(public name: string,
    public status: UserStatus) {}

  isActive(): boolean {
    return this.status === UserStatus.active;
  }
}
