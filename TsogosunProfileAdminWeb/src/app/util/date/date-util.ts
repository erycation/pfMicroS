import {NgbDate} from '@ng-bootstrap/ng-bootstrap';

export class DateUtil {

  static toNgbDate(date: string) {
    if (date) {
      const [year, month, day] = date.split('-');
      return new NgbDate(parseInt(year), parseInt(month), parseInt(day.split(' ')[0].trim()));
    }
  }

  static startOfToday() {
    const now = new Date();
    return DateUtil.startOfDay(now);
  }

  static startOfDay(date) {
    return new Date(
      date.getFullYear(), date.getMonth(), date.getDate()
    );
  }

  static addDays(date, days) {
    let result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
  }

  static endOfToday() {
    const now = new Date();
    return DateUtil.endOfDay(now);
  }

  private static endOfDay(date: Date) {
    date.setHours(23, 59, 59, 999);
    return date;
  }
}