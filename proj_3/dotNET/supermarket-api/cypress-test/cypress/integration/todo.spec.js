
describe('The Home Page', function() {
    it('successfully loads', function() {

      cy.visit('/swagger/index.html')
    
      cy.request('/api/categories')
      .then((response) => {
        expect(response.status).to.equal(200);
        expect(response.body).to.not.be.null;
        
      
    })
      
    cy.request('/api/categories')
    .then((response) => {
        expect(response.body).should('name','Dairy')
    
        
    })



      //"https://localhost:5001");

            //RestRequest restRequest = new RestRequest("/api/categories
    })

  })

    //cy.request('GET')
    

