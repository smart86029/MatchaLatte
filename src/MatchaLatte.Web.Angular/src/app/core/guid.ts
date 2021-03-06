export class Guid {
  private static validator = new RegExp('^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$', 'i');
  private static empty = '00000000-0000-0000-0000-000000000000';
  private value: string;

  constructor(value: string) {
    if (!value) {
      throw new TypeError('Invalid argument; `value` has no value.');
    }

    this.value = Guid.isGuid(value) ? value : Guid.empty;
  }

  static isGuid(value: any): boolean {
    return value && (value instanceof Guid || Guid.validator.test(value.toString()));
  }

  equals(other: Guid): boolean {
    return Guid.isGuid(other) && this.value === other.toString();
  }

  toString(): string {
    return this.value;
  }
}
