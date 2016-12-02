import { GudbelldonAdministrationPage } from './app.po';

describe('gudbelldon-administration App', function() {
  let page: GudbelldonAdministrationPage;

  beforeEach(() => {
    page = new GudbelldonAdministrationPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
