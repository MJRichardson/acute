function loadNavbar(activeItem){
	  //load the navbar html into the div
	  $("div#navbar").load('navbar.html', function(){

		//remove the active class from all nav bar items
		  $("ul.nav > li").toggleClass('active', false);	
		  //and add it to the newly selected item
		  $("ul.nav > li#" + activeItem).toggleClass('active', true);
	  });
}

function scrollSpy(menuSelector, offset){
			$('body').scrollspy({target: menuSelector, offset: offset });

			$(menuSelector + ' li a').click(function(event){
				event.preventDefault();
				$($(this).attr('href'))[0].scrollIntoView();
				scrollBy(0, -offset);
			});

			$(menuSelector).affix();
}
