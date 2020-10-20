import { MDR_AngularTemplatePage } from './app.po';

describe('MDR_Angular App', function() {
  let page: MDR_AngularTemplatePage;

  beforeEach(() => {
    page = new MDR_AngularTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
