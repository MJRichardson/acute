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

function trackPageView() {
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-6250148-2', 'mjrichardson.github.io');
  ga('send', 'pageview');
}
