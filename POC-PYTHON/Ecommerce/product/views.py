from django.shortcuts import render
from django.http import JsonResponse

from rest_framework.decorators import api_view
from rest_framework.response import Response
from .serializers import ProductsSerializer
from .models import Products

# Create your views here.
@api_view(['GET'])
def apiOverview(request):
    api_urls = {
		'List':'/product-list/',
		'Detail View':'/product-detail/<str:pk>(primary key)/',
		'Create':'/product-create/',
		'Update':'/product-update/<str:pk>/',
		'Delete':'/product-delete/<str:pk>/',
		}
    return Response(api_urls)

@api_view(['GET'])
def productList(request):
	product = Products.objects.all().order_by('productId')
	serializer =  ProductsSerializer(product, many=True)
	return Response(serializer.data)
'''
@api_view(['GET'])
def ProductDetail(request, pk):
	product = Products.objects.get(productId=pk)
	serializer = ProductsSerializer(product, many=False)
	return Response(serializer.data)
'''
@api_view(['GET'])
def ProductDetail(request, pk):
	try:
		product = Products.objects.get(productId=pk) 
	except Products.DoesNotExist:
		return JsonResponse({'Error':'The product does not exist', status:status.HTTP_404_NOT_FOUND})
	serializer = ProductsSerializer(product, many=False)
	return Response(serializer.data)


@api_view(['POST'])
def ProductCreate(request):
	serializer = ProductsSerializer(data=request.data)

	if serializer.is_valid():
		serializer.save()
	else:
		return Response("Data not in proper format")
	return Response(serializer.data)

@api_view(['PUT'])
def ProductUpdate(request, pk):
	product = Products.objects.get(productId=pk)
	serializer = ProductsSerializer(instance=product, data=request.data)
	if serializer.is_valid():
		serializer.save()
	else:
		return Response("Data not in proper format")

	return Response(serializer.data)


@api_view(['DELETE'])
def ProductDelete(request, pk):
	try:
		product = Products.objects.get(productId=pk) 
	except Products.DoesNotExist:
		return JsonResponse({'Error':'The product does not exist', status:status.HTTP_404_NOT_FOUND})
	product.delete()

	return Response('Item succsesfully delete!')



'''

@api_view(['DELETE'])
def ProductDelete(request, pk):
	product = Products.objects.get(productId=pk)
	
	product.delete()

	return Response('Item succsesfully delete!')
'''

