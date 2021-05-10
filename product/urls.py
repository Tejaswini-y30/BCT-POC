from django.urls import path

from rest_framework.documentation import include_docs_urls
from . import views

#schema_view = get_swagger_view(title="Swagger Docs")

urlpatterns = [
	path('', views.apiOverview, name="api-overview"),
	path('product-list/', views.productList, name="product-list"),
	path('product-detail/<str:pk>/', views.ProductDetail, name="product-detail"),
	path('product-create', views.ProductCreate, name="product-create"),
	path('product-update/<str:pk>/', views.ProductUpdate, name="product-update"),
	path('product-delete/<str:pk>/', views.ProductDelete, name="product-delete"),
	#path(r'^docs/', schema_view),
]
